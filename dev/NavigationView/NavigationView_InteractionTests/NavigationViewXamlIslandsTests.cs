﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Common;
using Windows.UI.Xaml.Tests.MUXControls.InteractionTests.Common;
using Windows.UI.Xaml.Tests.MUXControls.InteractionTests.Infra;

#if USING_TAEF
using WEX.TestExecution;
using WEX.TestExecution.Markup;
using WEX.Logging.Interop;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
#endif

#if BUILD_WINDOWS
using System.Windows.Automation;
using MS.Internal.Mita.Foundation;
using MS.Internal.Mita.Foundation.Controls;
using MS.Internal.Mita.Foundation.Patterns;
using MS.Internal.Mita.Foundation.Waiters;
#else
using Microsoft.Windows.Apps.Test.Automation;
using Microsoft.Windows.Apps.Test.Foundation;
using Microsoft.Windows.Apps.Test.Foundation.Controls;
using Microsoft.Windows.Apps.Test.Foundation.Patterns;
using Microsoft.Windows.Apps.Test.Foundation.Waiters;
#endif

namespace Windows.UI.Xaml.Tests.MUXControls.InteractionTests
{
    // Disabled due to bug Bug 19370504: Dependencies for a centennial wpf app not created automatically.
    // Microsoft.VCLibs.140.00.Debug specifically is not installed
    // [TestClass]
    public class NavigationViewXamlIslandsTests
    {
        [ClassInitialize]
        [TestProperty("RunAs", "User")]
        [TestProperty("Classification", "Integration")]
        [TestProperty("TestPass:IncludeOnlyOn", "Desktop")]
        public static void ClassInitialize(TestContext testContext)
        {
            TestEnvironment.Initialize(testContext, TestType.WPFXAMLIsland); 
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestEnvironment.AssemblyCleanupWorker(TestType.WPFXAMLIsland);
        }

        [TestMethod]
        public void XamlIslandNavViewTest()
        {
            if (!PlatformConfiguration.IsOsVersionGreaterThan(OSVersion.Redstone5))
            {
                // UIA in Xaml islands is only available in RS6
                return;
            }

            using (var setup = new TestSetupHelper("NavigationView Tests"))
            {
                var openButton = new Button(FindElement.ByName("Open Navigation"));
                Verify.IsNotNull(openButton);
                openButton.Click();
                var closeButton = new Button(FindElement.ByName("Close Navigation"));
                Verify.IsNotNull(closeButton);
                closeButton.Click();
            }
        }
    }
}
