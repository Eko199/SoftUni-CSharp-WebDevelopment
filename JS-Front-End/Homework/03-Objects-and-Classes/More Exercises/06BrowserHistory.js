function solve(browser, actions) {
    const commandExecutor = {
        "Open": openTab,
        "Close": closeTab,
        "Clear": clearBrowser
    };

    actions.forEach(action => {
        const [command, site] = action.split(" ");

        if (commandExecutor[command](site)) {
            browser["Browser Logs"].push(action);
        }
    });

    console.log(browser["Browser Name"]);
    console.log(`Open Tabs: ${browser["Open Tabs"].join(", ")}`);
    console.log(`Recently Closed: ${browser["Recently Closed"].join(", ")}`);
    console.log(`Browser Logs: ${browser["Browser Logs"].join(", ")}`);

    function openTab(site) {
        browser["Open Tabs"].push(site);
        return true;
    }

    function closeTab(site) {
        const tabIndex = browser["Open Tabs"].indexOf(site);

        if (tabIndex === -1) {
            return false;
        }

        browser["Open Tabs"].splice(tabIndex, 1);
        browser["Recently Closed"].push(site);

        return true;
    }

    function clearBrowser() {
        browser["Open Tabs"] = [];
        browser["Recently Closed"] = [];
        browser["Browser Logs"] = [];

        return false;
    }
}