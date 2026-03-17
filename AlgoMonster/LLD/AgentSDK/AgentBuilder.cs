using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonster.LLD.AgentSDK
{
    // Fluent builder — this is what teams use to configure an agent
    public class AgentBuilder
    {
        private string _model = "gpt-4o";
        private string _systemPrompt = string.Empty;
        private readonly List<IAgentTool> _tools = new();
        private readonly List<IGuardrail> _guardrails = new();
        private int _maxIterations = 10;

        public AgentBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public AgentBuilder WithSystemPrompt(string prompt)
        {
            _systemPrompt = prompt;
            return this;
        }

        public AgentBuilder WithTool(IAgentTool tool)
        {
            _tools.Add(tool);
            return this;
        }

        public AgentBuilder WithGuardrail(IGuardrail guardrail)
        {
            _guardrails.Add(guardrail);
            return this;
        }

        public AgentBuilder WithMaxIterations(int max)
        {
            _maxIterations = max;
            return this;
        }

        public IAgent Build()
        {
            // Validate required config
            if (string.IsNullOrEmpty(_systemPrompt))
                throw new InvalidOperationException(
                    "System prompt is required. Agents must have a defined purpose.");

            return new LlmAgent(_model, _systemPrompt, _tools, _guardrails, _maxIterations);
        }
    }
}
