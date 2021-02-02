﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.4.0.0
//      SpecFlow Generator Version:3.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Specflow.Practice.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Validate, fill and test web page forms")]
    public partial class ValidateFillAndTestWebPageFormsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "FillingOutForms.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Validate, fill and test web page forms", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Fill and test web page form without Captcha")]
        [NUnit.Framework.CategoryAttribute("UltimateQAOpen")]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "Success", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "Failure", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "RequiredFieldsNotFilled", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "\" \"", "RequiredField2NotFilled", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "Test", "RequiredField1NotFilled", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "MessageWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "NameWarning", null)]
        public virtual void FillAndTestWebPageFormWithoutCaptcha(string name, string message, string text, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "UltimateQAOpen"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("name", name);
            argumentsOfScenario.Add("message", message);
            argumentsOfScenario.Add("text", text);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fill and test web page form without Captcha", null, tagsOfScenario, argumentsOfScenario);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given("correct URL https://ultimateqa.com/filling-out-forms/ is entered in the browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.When(string.Format("name {0} in the Name field and message {1} in the Message field are filled in for" +
                            "m Form1", name, message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
  testRunner.And("Submit Button1 button is clicked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 9
 testRunner.Then(string.Format("a text {0} message is shown on the page", text), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Fill and test web page form with Captcha")]
        [NUnit.Framework.CategoryAttribute("UltimateQAOpen")]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "correct", "Success", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "wrong", "WrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "empty", "CapthcaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "correct", "WarningNameMessage", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "wrong", "WarningNameMessageErrorCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "empty", "WarningAll", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "correct", "RequiredFieldsNotFilled", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "wrong", "WrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "empty", "CapthcaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "correct", "NameWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "correct", "MessageWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "wrong", "NameWarningErrorCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "wrong", "MessageWarningErrorCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "empty", "WarningNameCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "empty", "WarningMessageCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "\" \"", "correct", "RequiredFieldNotFilled", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "Test", "correct", "RequiredFieldNotFilled", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "\" \"", "wrong", "WrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "Test", "wrong", "WrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "\" \"", "empty", "CapthcaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "Test", "empty", "CapthcaWarning", null)]
        public virtual void FillAndTestWebPageFormWithCaptcha(string name, string message, string captcha, string text, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "UltimateQAOpen"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("name", name);
            argumentsOfScenario.Add("message", message);
            argumentsOfScenario.Add("captcha", captcha);
            argumentsOfScenario.Add("text", text);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fill and test web page form with Captcha", null, tagsOfScenario, argumentsOfScenario);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 25
 testRunner.Given("correct URL https://ultimateqa.com/filling-out-forms/ is entered in the browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 26
 testRunner.When(string.Format("name {0} in the Name field and message {1} in the Message field are filled in for" +
                            "m Form2", name, message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 27
  testRunner.And(string.Format("captcha sum {0} is filled in the Captcha field", captcha), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
  testRunner.And("Submit Button2 button is clicked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
 testRunner.Then(string.Format("a text {0} message is shown on the page above the form with Captcha", text), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Fill and test web page form with Email and Captcha")]
        [NUnit.Framework.CategoryAttribute("UltimateQAOpen")]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "TestEmail@email.com", "correct", "Success", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "TestEmail@email.com", "wrong", "WrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "TestEmail@email.com", "empty", "CaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "TestEmail@", "correct", "InvalidEmail", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "TestEmail", "wrong", "InvalidEmailWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "TestEmail@", "empty", "InvalidEmailCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "", "correct", "EmailWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "", "wrong", "EmailWarningWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "", "empty", "EmailCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "\" \"", "correct", "RequiredFieldNotFilled", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "\" \"", "wrong", "WrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", "\" \"", "empty", "CaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "", "correct", "NameEmailMessageWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "", "wrong", "NameEmailMessageWarningWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "", "empty", "NameEmailMessageCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "TestEmail@email.com", "correct", "NameMessageWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "TestEmail@email.com", "wrong", "NameMessageWarningWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "TestEmail@email.com", "empty", "NameMessageCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "TestEmail@email.com", "correct", "MessageWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "TestEmail@email.com", "wrong", "MessageWarningWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "TestEmail@email.com", "empty", "MessageCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "TestEmail@email.com", "correct", "NameWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "TestEmail@email.com", "wrong", "NameWarningWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "TestEmail@email.com", "empty", "NameCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "", "correct", "EmailMessageWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "", "wrong", "EmailMessageWarningWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "", "empty", "EmailMessageCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "", "correct", "NameEmailWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "", "wrong", "NameEmailWarningWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "", "empty", "NameEmailCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "123", "correct", "InvalidEmailNameWarning", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "123", "wrong", "InvalidEmailNameWarningWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "123", "empty", "InvalidEmailNameCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "123", "correct", "InvalidEmailMessageWarning", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "123", "wrong", "InvalidEmailMessageWarningWrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("Test", "", "123", "empty", "InvalidEmailMessageCaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "\" \"", "correct", "RequiredFields3NotFilled", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "\" \"", "wrong", "WrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "\" \"", "empty", "CaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "TestEmail@email.com", "correct", "RequiredFields2NotFilled", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "TestEmail@email.com", "wrong", "WrongNumberInCaptcha", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "TestEmail@email.com", "empty", "CaptchaWarning", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "\" \"", "TestEmail@", "correct", "InvalidEmail", null)]
        public virtual void FillAndTestWebPageFormWithEmailAndCaptcha(string name, string message, string email, string captcha, string text, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "UltimateQAOpen"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("name", name);
            argumentsOfScenario.Add("message", message);
            argumentsOfScenario.Add("email", email);
            argumentsOfScenario.Add("captcha", captcha);
            argumentsOfScenario.Add("text", text);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fill and test web page form with Email and Captcha", null, tagsOfScenario, argumentsOfScenario);
#line 58
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 59
 testRunner.Given("correct URL https://ultimateqa.com/complicated-page/ is entered in the browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 60
 testRunner.When("the page is scrolled down to the form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 61
  testRunner.And(string.Format("name {0} is filled in the Name field", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 62
  testRunner.And(string.Format("message {0} is filled in the Message field", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
  testRunner.And(string.Format("email {0} is filled in the Email field", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 64
  testRunner.And(string.Format("captcha sum {0} is filled in the Captcha field in the form with Email", captcha), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
  testRunner.And("Submit Button3 button is clicked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
 testRunner.Then(string.Format("a text {0} message is shown on the page above the form with Email and Captcha", text), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
