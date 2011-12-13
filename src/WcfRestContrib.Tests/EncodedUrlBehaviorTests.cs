﻿using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using NUnit.Framework;
using Should;

namespace WcfRestContrib.Tests
{
    [TestFixture]
    public class EncodedUrlBehaviorTests
    {
        [ServiceContract]
        public class Service
        {            
            [WebGet(UriTemplate = "/{value}")]
            [OperationContract]
            public string Method(string value)
            {
                return value;
            }
        }

        [Test]
        public void Should_Accept_Url_With_Encoded_Backslash()
        {
            using (var host = new Host<Service>("http://localhost:48645/"))
            {
                var response = host.Get("me%2fyou");

                response.StatusCode.ShouldEqual(HttpStatusCode.OK);
                response.Content.ShouldContain("me/you");
            }
        }
    }
}