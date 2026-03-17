using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.LLD.AgentSDK
{
    /**
     * 
     * ### Step 1: Clarify

    > *"A few questions — 
        is this SDK consumed internally by Disney engineering teams in C#, or polyglot? 
        Should agents be stateless or support conversation memory? 
        Do we need built-in guardrails, or is that a separate concern? 
        And are we designing the interface today or the full implementation?"*

        Assume: **internal C# SDK, stateful conversation support, built-in guardrails, interface + one implementation.**

     * 
     * ### Step 2: Identify entities
        ```
        IAgent               — the core contract every agent implements
        AgentBuilder         — fluent builder for constructing agents
        AgentContext         — conversation state passed through each turn
        IAgentTool           — interface for tools the agent can call
        IGuardrail           — pre/post processing safety checks
        AgentResponse        — structured result returned to caller
     * **/

    // Core agent contract
    public interface IAgent
    {
        Task<AgentResponse> InvokeAsync(string userMessage, AgentContext context);
    }

    // Tool interface — any capability the agent can use
    public interface IAgentTool
    {
        string Name { get; }
        string Description { get; }  // LLM reads this to decide when to call it
        Task<string> ExecuteAsync(string input);
    }

    // Guardrail — runs before and/or after LLM call
    public interface IGuardrail
    {
        Task<GuardrailResult> CheckInputAsync(string input);
        Task<GuardrailResult> CheckOutputAsync(string output);
    }

    public record AgentContext(
        string SessionId,
        List<Message> ConversationHistory,
        Dictionary<string, object> Metadata
    );

    public record AgentResponse(
        string Content,
        bool WasBlocked,       // true if a guardrail rejected it
        string? BlockReason,
        List<ToolCall> ToolCallsMade,
        int TokensUsed
    );

    public record GuardrailResult(bool Passed, string? FailureReason);
    public record ToolCall(string ToolName, string Input, string Output);

    public class Message
    { 
        // todo
    }
}
