class Process {
	constructor(id, name) {
		this.id = id;
		this.name = name;
		this.messageQueue = [];
	}

	sendMessage(message) {
		this.messageQueue.push(message);
	}

	receiveMessage() {
		return this.messageQueue.shift();
	}
}

class ProcessManager {
	constructor() {
		this.processes = {};
		this.nextId = 1;
	}

	createProcess(name) {
		const id = this.nextId++;
		const process = new Process(id, name);
		this.processes[id] = process;
		console.dir(`Process ${name} created with ID ${id}`, {});
		return process;
	}

	listProcesses() {
		console.log("\x1b[36m%s\x1b[0m", "Listing current processes...");
		const processIds = Object.keys(this.processes);
		processIds.forEach((id, index) => {
			setTimeout(() => {
				const process = this.processes[id];
				console.log("\x1b[33m%s\x1b[0m", `ID: ${id}, Name: ${process.name}`);
			}, index * 1000); // Timeout de 1 segundo para cada processo
		});
	}

	sendMessage(senderId, receiverId, message) {
		const sender = this.processes[senderId];
		const receiver = this.processes[receiverId];
		if (sender && receiver) {
			receiver.sendMessage(`Message from ${sender.name}: ${message}`);
			console.log("\x1b[32m%s\x1b[0m", `Message sent from ${sender.name} to ${receiver.name}`);
		} else {
			console.log("\x1b[31m%s\x1b[0m", "Invalid sender or receiver ID");
		}
	}

	receiveMessage(processId) {
		const process = this.processes[processId];
		if (process) {
			const message = process.receiveMessage();
			if (message) {
				console.log("\x1b[32m%s\x1b[0m", `Process ${process.name} received message: ${message}`);
			} else {
				console.log("\x1b[33m%s\x1b[0m", `No messages for process ${process.name}`);
			}
		} else {
			console.log("\x1b[31m%s\x1b[0m", "Invalid process ID");
		}
	}

	terminateProcess(id) {
		if (this.processes[id]) {
			delete this.processes[id];
			console.log("\x1b[31m%s\x1b[0m", `Process with ID ${id} terminated`);
		} else {
			console.log("\x1b[31m%s\x1b[0m", "Invalid process ID");
		}
	}
}

const manager = new ProcessManager();
const p1 = manager.createProcess("Process1");
const p2 = manager.createProcess("Process2");

setTimeout(() => {
	manager.listProcesses();

	setTimeout(() => {
		manager.sendMessage(p1.id, p2.id, "Hello from Process1");

		setTimeout(() => {
			manager.receiveMessage(p2.id);

			setTimeout(() => {
				manager.terminateProcess(p1.id);

				setTimeout(() => {
					manager.listProcesses();
				}, 1000);
			}, 1000);
		}, 1000);
	}, 1000);
}, 1000);
