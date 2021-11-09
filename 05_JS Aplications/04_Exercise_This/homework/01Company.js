class Company {

    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username || !salary || !position || !department) {
            throw new Error("Invalid input!");
        }

        if (salary < 0) {
            throw new Error(" Invalid input!");
        }


        let currentDepartment = this.departments.find(x => x.department === department)

        if (!currentDepartment) {
            currentDepartment = {
                department: department,
                employees: []
            };

            this.departments.push(currentDepartment)
        }

        currentDepartment.employees.push({
            username: username,
            salary: salary,
            position: position
        });

        return ` New employee is hired. Name: ${username}. Position: ${position}`
    }

    bestDepartment() {
            const department = this.departments
                .sort((a, b) =>
                    b.employees
                    .reduce((x, y) =>
                        x + y) - a.employees
                    .reduce((x, y) =>
                        x + y))[0];

            return `Best Department is: ${department.department}\nAverage salary: ${(department
        .employees
        .map(x =>
            x.salary)
        .reduce((x, y) =>
            x + y) / department.employees.length)
            .toFixed(2)}\n${department
                .employees
                .sort((a, b) =>
                    b.salary - a.salary || a.username.localeCompare(b.username))
                .map(x =>
                    `${x.username} ${x.salary} ${x.position}`)
                .join("\n")}`;
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