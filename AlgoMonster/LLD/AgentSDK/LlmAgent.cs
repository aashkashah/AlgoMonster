using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.LLD.AgentSDK
{
    internal class LlmAgent : IAgent
    {
        private readonly string _model;
        private readonly string _systemPrompt;
        private readonly List<IAgentTool> _tools;
        private readonly List<IGuardrail> _guardrails;
        private readonly int _maxIterations;

        internal LlmAgent(
            string model, string systemPrompt,
            List<IAgentTool> tools, List<IGuardrail> guardrails,
            int maxIterations)
        {
            _model = model;
            _systemPrompt = systemPrompt;
            _tools = tools;
            _guardrails = guardrails;
            _maxIterations = maxIterations;
        }

        public async Task<AgentResponse> InvokeAsync(
            string userMessage, AgentContext context)
        {
            // Step 1: run input guardrails
            foreach (var guardrail in _guardrails)
            {
                var inputCheck = await guardrail.CheckInputAsync(userMessage);
                if (!inputCheck.Passed)
                    return new AgentResponse(
                        Content: "I can't help with that.",
                        WasBlocked: true,
                        BlockReason: inputCheck.FailureReason,
                        ToolCallsMade: new(),
                        TokensUsed: 0);
            }

            // Step 2: agent loop — reason, act, observe, repeat
            var toolCallsMade = new List<ToolCall>();
            var iterations = 0;
            string finalAnswer = string.Empty;

            while (iterations < _maxIterations)
            {
                iterations++;

                // Call LLM — in real impl this hits Azure OpenAI endpoint
                var llmResponse = await CallLlmAsync(userMessage, context, toolCallsMade);

                // If LLM wants to call a tool
                if (llmResponse.WantsToolCall)
                {
                    var tool = _tools.FirstOrDefault(t => t.Name == llmResponse.ToolName);
                    if (tool is null) break;  // tool not found — stop loop

                    var toolOutput = await tool.ExecuteAsync(llmResponse.ToolInput!);
                    toolCallsMade.Add(new ToolCall(tool.Name, llmResponse.ToolInput!, toolOutput));
                    // loop continues — LLM sees tool output and decides next step
                }
                else
                {
                    // LLM has a final answer — exit loop
                    finalAnswer = llmResponse.Content;
                    break;
                }
            }

            // Graceful degradation if max iterations hit
            if (string.IsNullOrEmpty(finalAnswer))
                finalAnswer = "I wasn't able to complete this task. Please try rephrasing.";

            // Step 3: run output guardrails
            foreach (var guardrail in _guardrails)
            {
                var outputCheck = await guardrail.CheckOutputAsync(finalAnswer);
                if (!outputCheck.Passed)
                    return new AgentResponse(
                        Content: "I can't return that response.",
                        WasBlocked: true,
                        BlockReason: outputCheck.FailureReason,
                        ToolCallsMade: toolCallsMade,
                        TokensUsed: 0);
            }

            return new AgentResponse(
                Content: finalAnswer,
                WasBlocked: false,
                BlockReason: null,
                ToolCallsMade: toolCallsMade,
                TokensUsed: EstimateTokens(toolCallsMade));
        }

        private class LlmDecision
        {
            public bool WantsToolCall { get; internal set; }
            public string Content { get; internal set; }
            public string ToolInput { get; internal set; }
            public string ToolName { get; internal set; }
        }


        // Placeholder — real impl calls Azure OpenAI SDK
        private Task<LlmDecision> CallLlmAsync(
         string message, AgentContext context, List<ToolCall> history)
         => throw new NotImplementedException("Wire to Azure OpenAI SDK");

        private int EstimateTokens(List<ToolCall> calls) => calls.Count * 500; // rough estimate
    }
}
