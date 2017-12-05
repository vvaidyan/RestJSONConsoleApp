using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestJSONConsoleApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetDataByStateNameIsNull()
        {
            StateData[] array =
            {
                new StateData() {StateName = "Alaska", StateAbbr = "AK", LargestCity = "Anchorage", Capital = "Juneau"},
                new StateData() {StateName = "Florida", StateAbbr = "FL", LargestCity = "Jacksonville", Capital = "Tallahassee"},
            };

            //expected result is NULL
            var res = Program.GetDataByStateName(array, "Alabama");
            Assert.AreEqual(res, null);
        }


        [TestMethod]
        public void GetDataByStateAbbrIsNull()
        {
            StateData[] array =
            {
                new StateData() {StateName = "Alaska", StateAbbr = "AK", LargestCity = "Anchorage", Capital = "Juneau"},
                new StateData() {StateName = "Florida", StateAbbr = "FL", LargestCity = "Jacksonville", Capital = "Tallahassee"},
            };

            //expected result is NULL
            var res = Program.GetDataByStateAbbr(array, "TT");
            Assert.AreEqual(res, null);
        }


        [TestMethod]
        public void GetDataByStateNameIsEqual()
        {
            StateData[] array =
            {
                new StateData() {StateName = "Alaska", StateAbbr = "AK", LargestCity = "Anchorage", Capital = "Juneau"},
                new StateData() {StateName = "Florida", StateAbbr = "FL", LargestCity = "Jacksonville", Capital = "Tallahassee"},
            };

            //expected result is NULL
            var res = Program.GetDataByStateName(array, "Alaska");
            Assert.AreEqual(res.LargestCity.ToString(), "Anchorage");
            Assert.AreEqual(res.Capital.ToString(), "Juneau");
        }


        [TestMethod]
        public void GetDataByStateNameNotEqual()
        {
            StateData[] array =
            {
                new StateData() {StateName = "Alaska", StateAbbr = "AK", LargestCity = "Anchorage", Capital = "Juneau"},
                new StateData() {StateName = "Florida", StateAbbr = "FL", LargestCity = "Jacksonville", Capital = "Tallahassee"},
            };

            //expected result is NULL
            var res = Program.GetDataByStateName(array, "Alaska");
            Assert.AreNotEqual(res.LargestCity.ToString(), "XYZ");
            Assert.AreNotEqual(res.Capital.ToString(), "ABC");
        }


        [TestMethod]
        public void GetDataByStateAbbrIsEqual()
        {
            StateData[] array =
            {
                new StateData() {StateName = "Alaska", StateAbbr = "AK", LargestCity = "Anchorage", Capital = "Juneau"},
                new StateData() {StateName = "Florida", StateAbbr = "FL", LargestCity = "Jacksonville", Capital = "Tallahassee"},
            };

            //expected result is NULL
            var res = Program.GetDataByStateAbbr(array, "AK");
            Assert.AreEqual(res.LargestCity.ToString(), "Anchorage");
            Assert.AreEqual(res.Capital.ToString(), "Juneau");
        }


        [TestMethod]
        public void GetDataByStateAbbrNotEqual()
        {
            StateData[] array =
            {
                new StateData() {StateName = "Alaska", StateAbbr = "AK", LargestCity = "Anchorage", Capital = "Juneau"},
                new StateData() {StateName = "Florida", StateAbbr = "FL", LargestCity = "Jacksonville", Capital = "Tallahassee"},
            };

            //expected result is NULL
            var res = Program.GetDataByStateAbbr(array, "FL");
            Assert.AreNotEqual(res.LargestCity.ToString(), "XYZ");
            Assert.AreNotEqual(res.Capital.ToString(), "ABC");
        }
    }
}
