using InsuranceManagementSystem.dao;
using InsuranceManagementSystem.Entity;
using InsuranceManagementSystem.Exceptions;
using NUnit.Framework;
using System.Collections.Generic;

namespace InsuranceManagementSystem.Tests
{
    [TestFixture]
    public class PolicyServiceImplTests
    {
        private IPolicyService _service;

        [SetUp]
        public void Setup()
        {
            _service = new PolicyServiceImpl();

            // Ensure a clean test policy exists before every test
            try { _service.DeletePolicy(999); } catch { }

            var testPolicy = new Policy(999, "Test Policy", 1200.50, "Unit test coverage");
            _service.CreatePolicy(testPolicy);
        }

        [TearDown]
        public void Cleanup()
        {
            // Clean up test data after each test
            try { _service.DeletePolicy(999); } catch { }
        }

        [Test]
        public void CreatePolicy_ShouldReturnTrue_WhenValidPolicyIsProvided()
        {
            var newPolicy = new Policy(998, "Another Policy", 1500.00, "Another coverage");
            bool result = _service.CreatePolicy(newPolicy);

            Assert.IsTrue(result);

            // Clean up
            _service.DeletePolicy(998);
        }

        [Test]
        public void GetPolicy_ShouldReturnCorrectPolicy_WhenPolicyExists()
        {
            var policy = _service.GetPolicy(999);

            Assert.IsNotNull(policy);
            Assert.AreEqual("Test Policy", policy.PolicyName);
            Assert.AreEqual(1200.50, policy.PremiumAmount);
        }

        [Test]
        public void GetPolicy_ShouldThrowException_WhenPolicyDoesNotExist()
        {
            Assert.Throws<PolicyNotFoundException>(() => _service.GetPolicy(8888));
        }

        [Test]
        public void UpdatePolicy_ShouldReturnTrue_WhenPolicyIsUpdated()
        {
            var updatedPolicy = new Policy(999, "Updated Policy", 2000.00, "Updated coverage");
            bool result = _service.UpdatePolicy(updatedPolicy);

            Assert.IsTrue(result);

            var policy = _service.GetPolicy(999);
            Assert.AreEqual("Updated Policy", policy.PolicyName);
            Assert.AreEqual(2000.00, policy.PremiumAmount);
        }

        [Test]
        public void GetAllPolicies_ShouldReturnAtLeastOnePolicy()
        {
            var allPolicies = _service.GetAllPolicies();
            Assert.IsNotNull(allPolicies);
            Assert.IsTrue(allPolicies.Count > 0);
        }

        [Test]
        public void DeletePolicy_ShouldReturnTrue_WhenPolicyExists()
        {
            var tempPolicy = new Policy(997, "ToDelete", 1000, "To be deleted");
            _service.CreatePolicy(tempPolicy);

            bool result = _service.DeletePolicy(997);
            Assert.IsTrue(result);
        }

        [Test]
        public void DeletePolicy_ShouldThrowException_WhenPolicyDoesNotExist()
        {
            Assert.Throws<PolicyNotFoundException>(() => _service.DeletePolicy(8888));
        }
    }
}
