// 代码生成时间: 2025-10-13 21:30:50
using System;
using System.Collections.Generic;

namespace RiskManagement
{
    // The RiskLevel enumeration represents the different levels of risk.
    public enum RiskLevel
    {
        Low,
        Medium,
        High
    }

    // The RiskEvent class represents a risk event with its associated level.
    public class RiskEvent
    {
        public string EventName { get; set; }
        public RiskLevel Level { get; set; }

        public RiskEvent(string eventName, RiskLevel level)
        {
            EventName = eventName;
            Level = level;
        }
    }

    // The RiskControl class is responsible for managing the risk events.
    public class RiskControl
    {
        private List<RiskEvent> riskEvents = new List<RiskEvent>();

        // Adds a new risk event to the system.
        public void AddRiskEvent(RiskEvent riskEvent)
        {
            if (riskEvent == null)
                throw new ArgumentNullException(nameof(riskEvent), "Risk event cannot be null.");

            riskEvents.Add(riskEvent);
            Console.WriteLine($"Risk event '{riskEvent.EventName}' added with level {riskEvent.Level}.");
        }

        // Evaluates the risk level of the system based on the added risk events.
        public void EvaluateRisk()
        {
            int highRiskCount = 0;
            int mediumRiskCount = 0;

            foreach (var riskEvent in riskEvents)
            {
                switch (riskEvent.Level)
                {
                    case RiskLevel.High:
                        highRiskCount++;
                        break;
                    case RiskLevel.Medium:
                        mediumRiskCount++;
                        break;
                }
            }

            if (highRiskCount > 0)
            {
                Console.WriteLine("There are high risk events detected. System is at risk.");
            }
            else if (mediumRiskCount > 0)
            {
                Console.WriteLine("There are medium risk events detected. Please review.");
            }
            else
            {
                Console.WriteLine("System is considered safe with no high or medium risk events.");
            }
        }
    }

    // Program class to demonstrate the usage of RiskControl system.
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RiskControl riskControl = new RiskControl();

                // Adding risk events to the system.
                riskControl.AddRiskEvent(new RiskEvent("Data Breach", RiskLevel.High));
                riskControl.AddRiskEvent(new RiskEvent("System Downtime", RiskLevel.Medium));
                riskControl.AddRiskEvent(new RiskEvent("Minor Bug", RiskLevel.Low));

                // Evaluating the risk level of the system.
                riskControl.EvaluateRisk();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}