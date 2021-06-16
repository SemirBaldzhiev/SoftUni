class Company{
    constructor(){
        this.departments = [];
    }

    addEmployee(name, salary, position, department){
        if (!name || !salary || !position || !department || salary < 0) {
            throw new Error('Invalid input!');
        }

        let employee = {
            name: name,
            salary: Number(salary),
            position: position,
        }


        if (!this.departments[department]) {
            this.departments[department] = [];
        }   
        

        this.departments[department].push(employee);

        return `New employee is hired. Name: ${name}. Position: ${position}`
    }


    bestDepartment(){

        let bestAvgSalary = 0;
        let department = '';
        
        Object.entries(this.departments).forEach(([key, value]) => {
            
            let avgSalary = 0;

            value.forEach(e => {
                avgSalary += e.salary;
            });

            avgSalary = avgSalary / value.length;
            

            if (avgSalary > bestAvgSalary) {
                bestAvgSalary = avgSalary;
                department = key;
            }

        });


        let result = `Best Department is: ${department}\nAverage salary: ${bestAvgSalary.toFixed(2)}\n`;

        let emplyees = this.departments[department];

        emplyees.sort((a, b) => b.salary - a.salary ||  a.name.localeCompare(b.name)).forEach(e => {
            result += `${e.name} ${e.salary} ${e.position}\n`
        });

        return result.trimEnd();
    }

}


let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
