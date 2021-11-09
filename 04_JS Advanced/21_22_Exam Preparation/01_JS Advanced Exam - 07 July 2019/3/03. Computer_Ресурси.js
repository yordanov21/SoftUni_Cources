class Computer {

    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory = hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];

    }
    //връща ranUsage  на всички отворени програми
    get totalRamUsage() {
        return this.taskManager.reduce((acc, curr) => acc + curr.ramUsage, 0);
    }

    //връща cpuUsage на всички отворени програми
    get totalCpuUsage() {
        return this.taskManager.reduce((acc, curr) => acc + curr.cpuUsage, 0);
    }


    installAProgram(name, requiredSpace) {
        if (this.hddMemory < requiredSpace) {
            throw new Error("There is not enough space on the hard drive");
        }

        let program = {
            name,
            requiredSpace
        }

        this.installedPrograms.push(program);
        this.hddMemory -= requiredSpace;

        return program;
    }


    uninstallAProgram(name) {
        const index = this.installedPrograms.findIndex(x => x.name === name);

        if (index === -1) {
            throw new Error("Control panel is not responding");
        }

        const memory = this.installedPrograms.find(x => x.name === name).requiredSpace;
        this.hddMemory += memory;
        this.installedPrograms.splice(index, 1);

        return this.installedPrograms;
    }

    openAProgram(name) {
        const programIndex = this.installedPrograms.findIndex((p) => p.name === name);
        if (programIndex === -1) {
            throw new Error(`The ${name} is not recognized`);
        }

        const openProgramIndex = this.taskManager.findIndex((p) => p.name === name);
        if (openProgramIndex > -1) {
            throw new Error(`The ${name} is already open`);
        }

        let proramRequiredSpace = this.installedPrograms[programIndex].requiredSpace;
        let ramUsage = (proramRequiredSpace / this.ramMemory) * 1.5;
        let cpuUsage = ((proramRequiredSpace / this.cpuGHz) / 500) * 1.5;

        if ((this.totalRamUsage + ramUsage) >= 100) {
            throw new Error(`${name} caused out of memory exception`);
        }

        if ((this.totalCpuUsage + cpuUsage >= 100)) {
            throw new Error(`${name} caused out of cpu exception`);
        }

        const program = {
            name: name,
            ramUsage: ramUsage,
            cpuUsage: cpuUsage
        };

        this.taskManager.push(program);

        return program;
    }

    taskManagerView() {
        if (this.taskManager.length === 0) {
            return "All running smooth so far";
        }

        return this.taskManager.
            map(x =>
                `Name - ${x.name} | Usage - CPU: ${x.cpuUsage.toFixed(0)}%, RAM: ${x.ramUsage.toFixed(0)}%`)
            .join("\n");
    }


}

let computer = new Computer(4096, 7.5, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.uninstallAProgram('Word');
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Excel');
computer.openAProgram('Solitare');

console.log(computer.installedPrograms);
console.log(('-').repeat(50)) // Separator
console.log(computer.taskManager);
