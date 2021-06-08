function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let textAreaElement = document.querySelector('#inputs textarea');

      let inputArr = JSON.parse(textAreaElement.value);  

      let restaurants = {};
      for (const el of inputArr) {
         let tokens = el.split(' - ');

         let restaurantName= tokens[0];
         let data = tokens[1].split(', ');
         
         let workersArr = [];

         for (const worker of data) {
            let workerData = worker.split(' ');
            
            workersArr.push({name: workerData[0], salary: Number(workerData[1])});

         }
         
         if (!restaurants[restaurantName]) {
            restaurants[restaurantName] = {
               restaurantName: restaurantName,
               workers: [],
               getAverageSalary: function (){
                  return this.workers.reduce((a, x) => a += x.salary, 0) / this.workers.length;
               }
            }
         }
         
         restaurants[restaurantName].workers = restaurants[restaurantName].workers.concat(workersArr);
      }

      let sortedRestaurants = Object.values(restaurants).sort((a, b) => b.getAverageSalary() - a.getAverageSalary());
      let bestRestaurant = sortedRestaurants[0];
      let sortedWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

      let avergaeSalary = bestRestaurant.getAverageSalary().toFixed(2);
      let bestSalary = bestRestaurant.workers[0].salary.toFixed(2);

      let topRestaurant = `Name: ${bestRestaurant.restaurantName} Average Salary: ${avergaeSalary} Best Salary: ${bestSalary}`;

      let bestRestaurantElement = document.querySelector('#bestRestaurant p')
      let bestWorkersElement = document.querySelector('#workers p')

      bestRestaurantElement.textContent = topRestaurant;
      
      let workersResult = [];
      sortedWorkers.forEach(w => {
         workersResult.push(`Name: ${w.name} With Salary: ${w.salary}`);
      });
      bestWorkersElement.textContent = workersResult.join(' ');
   }
}

//["PizzaHut - Peter 500, George 300, Mark 800",
//"TheLake - Bob 1300, Joe 780, Jane 660"]

