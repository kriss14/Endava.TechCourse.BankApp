﻿using Endava.TechCourse.BankApp.Application.Commands.TransferFounds;

namespace Endava.TechCourse.BankApp.Tests.ApplicationTests.CommandsTests
{
    public class TransferFoundsHandlerTests
    {
        [Test, ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(TransferFoundsHandler).GetConstructors());
    }
}