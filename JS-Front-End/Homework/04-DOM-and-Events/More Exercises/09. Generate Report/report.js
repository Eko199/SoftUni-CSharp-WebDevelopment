function generateReport() {
    const headers = Array.from(document.querySelectorAll("thead input"));

    const report = Array.from(document.querySelectorAll("tbody tr")).map(tr => {
        const reportObj = {};

        const data = Array.from(tr.getElementsByTagName("td"))
            .map(td => td.textContent);

        for (let i = 0; i < data.length; i++) {
            if (headers[i].checked) {
                reportObj[headers[i].name] = data[i];
            }
        }

        return reportObj;
    });

    document.getElementById("output").textContent = JSON.stringify(report);
}