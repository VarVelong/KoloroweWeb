<template>

    <body>

        <ul v-if="employees.length">
            <li v-for="employee in employees" :key="employee.id">
                {{employee}}
                <h2>{{employee.groupRed}}</h2>
            </li>
        </ul>
    </body>
</template>

<script>

export default {
    data() {
        return {
            employees: [],
            error: null
        };
    },

    mounted() {
        this.fetchEmployees();
    },

    //TODO MOVE TO EMPLOYER MODULE AND CREATE SERVICE!!!!

    methods: {
        async fetchEmployees() {
            this.error = null;
            try {
                let link = `https://localhost:7119/Employees`;
                const response = await fetch(link);
                if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }
                const data = await response.json();
                this.employees = data;
            } catch (err) {
                this.error = err.message;
            }
        },

        async updateEmployees(groupName, groupContent) {
            try {
                const url = `https://localhost:7119/Employees/${groupName}`;
                const response = await fetch(url, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(groupContent),
                });

                if (response.ok) {
                    const result = await response.text();
                    console.log(result);
                    this.$toast.success("Group updated successfully.");
                } else {
                    this.$toast.error(`Error: ${response.statusText}`);
                }
            } catch (error) {
                console.error("Network error:", error);
                this.$toast.error("Failed to connect to the server.");
            }
        },
    }
}

</script>

<style scoped>
body {
    background-color: #4CAF50;
    margin: 0 auto;
    padding: 0;
    color: #333;
    width: 80%;
    box-sizing: border-box;
}

div {
    background-color: #FFF9C4;
    border: 3px solid #FFD54F;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    max-width: 600px;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
}

h2 {
    color: #FF6F61;
    font-size: 2em;
    margin-bottom: 10px;
    text-shadow: 1px 1px #FFD9E8;
}

p {
    font-size: 1.2em;
    line-height: 1.5;
    margin: 5px 0;
    color: #555;
}
</style>