using System;
using TechTalk.SpecFlow;

namespace QA.Upskill.Program.Tests.Transformations
{
    [Binding]
    public class StepArgumentTransformations
    {
        [StepArgumentTransformation]
        public string TransformToSpace(string textParameter)
        {
            if (textParameter == "\" \"")
            {
                return " ";
            }

            return textParameter;
        }
    }
}
