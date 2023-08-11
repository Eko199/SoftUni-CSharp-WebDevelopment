function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      const restaurants = JSON.parse(document.querySelector("textarea").value)
         .reduce((acc, curr) => {
            const [name, workers] = curr.split(" - ");

            if (!acc.hasOwnProperty(name)) {
               acc[name] = {};
            }

            workers.split(", ").forEach(w => {
               const [workerName, salary] = w.split(" ");
               acc[name][workerName] = Number(salary);
            });

            return acc;
         }, {});

      const [bestRestaurant, workers] = Object.entries(restaurants)
         .sort((a, b) => 
            Object.values(b[1])
               .reduce((acc, curr) => acc + curr / Object.values(b[1]).length, 0) - 
            Object.values(a[1])
               .reduce((acc, curr) => acc + curr / Object.values(a[1]).length, 0))[0];
      
      const workersEntriesSorted = Object.entries(workers).sort((a, b) => b[1] - a[1]);

      document.querySelector("#bestRestaurant p").textContent = 
         `Name: ${bestRestaurant} Average Salary: ${Object.values(workers)
            .reduce((acc, curr) => acc + curr / Object.values(workers).length, 0).toFixed(2)} Best Salary: ${workersEntriesSorted[0][1].toFixed(2)}`;

      document.querySelector("#workers p").textContent = workersEntriesSorted
            .map(([name, salary]) => `Name: ${name} With Salary: ${salary}`)
            .join(" ");
   }
}