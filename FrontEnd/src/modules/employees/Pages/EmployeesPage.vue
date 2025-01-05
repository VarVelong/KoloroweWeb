<template>

    <div id="middle-block">
        <ul>
            <li>
                <div class="group-container">
                    <h2 class="page-title">Dyrekcja:</h2>
                    <div class="post-text" v-if="!isEditing.principals">{{ employee.principals }}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.principals" @click="isEditing.principals = true"
                        class="btn btn-warning fas fa-edit"></button>
                    <input class="modify-group" v-model="employee.principals" v-if="isEditing.principals" />
                    <button v-if="isEditing.principals"
                        @click="saveEmployee('Principals', employee.principals); isEditing.principals = false"
                        class="btn btn-success">Zapisz</button>
                    <button v-if="isEditing.principals" @click="isEditing.principals = false"
                        class="button-orange">cancel</button>
                </div>
                <div class="group-container">
                    <h2 class="page-title">Grupa Czerwona:</h2>
                    <div class="post-text" v-if="!isEditing.groupRed">{{ employee.groupRed }}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.groupRed" @click="isEditing.groupRed = true"
                        class="btn btn-warning fas fa-edit"></button>
                    <input class="modify-group" v-model="employee.groupRed" v-if="isEditing.groupRed" />
                    <button v-if="isEditing.groupRed"
                        @click="saveEmployee('GroupRed', employee.groupRed); isEditing.groupRed = false"
                        class="btn btn-success">Zapisz</button>
                    <button v-if="isEditing.groupRed" @click="isEditing.groupRed = false"
                        class="button-orange">cancel</button>
                </div>
                <div class="group-container">
                    <h2 class="page-title">Grupa Żółta:</h2>
                    <div class="post-text" v-if="!isEditing.groupYellow">{{ employee.groupYellow }}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.groupYellow" @click="isEditing.groupYellow = true"
                        class="btn btn-warning fas fa-edit"></button>
                    <input class="modify-group" v-model="employee.groupYellow" v-if="isEditing.groupYellow" />
                    <button v-if="isEditing.groupYellow"
                        @click="saveEmployee('GroupYellow', employee.groupYellow); isEditing.groupYellow = false"
                        class="btn btn-success">Zapisz</button>
                    <button v-if="isEditing.groupYellow" @click="isEditing.groupYellow = false"
                        class="button-orange">cancel</button>
                </div>
                <div class="group-container">
                    <h2 class="page-title">Grupa Niebieska:</h2>
                    <div class="post-text" v-if="!isEditing.groupBlue">{{ employee.groupBlue }}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.groupBlue" @click="isEditing.groupBlue = true"
                        class="btn btn-warning fas fa-edit"></button>
                    <input class="modify-group" v-model="employee.groupBlue" v-if="isEditing.groupBlue" />
                    <button v-if="isEditing.groupBlue"
                        @click="saveEmployee('GroupBlue', employee.groupBlue); isEditing.groupBlue = false"
                        class="btn btn-success">Zapisz</button>
                    <button v-if="isEditing.groupBlue" @click="isEditing.groupBlue = false"
                        class="button-orange">cancel</button>
                </div>
                <div class="group-container">
                    <h2 class="page-title">Grupa Zielona:</h2>
                    <div class="post-text" v-if="!isEditing.groupGreen">{{ employee.groupGreen }}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.groupGreen" @click="isEditing.groupGreen = true"
                        class="btn btn-warning fas fa-edit"></button>
                    <input class="modify-group" v-model="employee.groupGreen" v-if="isEditing.groupGreen" />
                    <button v-if="isEditing.groupGreen"
                        @click="saveEmployee('GroupGreen', employee.groupGreen); isEditing.groupGreen = false"
                        class="btn btn-success">Zapisz</button>
                    <button v-if="isEditing.groupGreen" @click="isEditing.groupGreen = false"
                        class="button-orange">cancel</button>
                </div>
                <div class="group-container">
                    <h2 class="page-title">Specjaliści:</h2>
                    <div class="post-text" v-if="!isEditing.specialists">{{ employee.specialists }}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.specialists" @click="isEditing.specialists = true"
                        class="btn btn-warning fas fa-edit"></button>
                    <input class="modify-group" v-model="employee.specialists" v-if="isEditing.specialists" />
                    <button v-if="isEditing.specialists"
                        @click="saveEmployee('Specialists', employee.specialists); isEditing.specialists = false"
                        class="btn btn-success">Zapisz</button>
                    <button v-if="isEditing.specialists" @click="isEditing.specialists = false"
                        class="button-orange">cancel</button>
                </div>
            </li>
        </ul>
    </div>
</template>

<script>
import EmployeeService from "../EmployeeService";

export default {
    data() {
        return {
            employee: {},
            error: null,
            isEditing: {
                principals: false,
                groupRed: false,
                groupYellow: false,
                groupBlue: false,
                groupGreen: false,
                specialists: false
            }
        };
    },

    mounted() {
        this.fetchEmployees();
    },

    methods: {
        async fetchEmployees() {
            this.loading = true;
            this.error = null;
            EmployeeService.fetchEmployees(this.id)
                .then((data) => {
                    this.employee = data;
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
        },

        async saveEmployee(groupName, content) {
            this.loading = true;
            this.error = null;
            EmployeeService.updateEmployee(groupName, content)
                .then((data) => {
                    this.post = data;
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
        }
    }
}

</script>

<style scoped>
#middle-block {
    background-color: rgba(0, 0, 0, 0.5);
    width: 80%;
    border: 3px solid black;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
    min-height: 100%;
}

.group-container{
    border: 3px solid black;
    border-radius: 15px;
    background-color: #ddd;
    margin: 15px;
    padding: 15px;
}

ul {
    list-style-type: none;
    padding: 0;
}

li {
    padding: 15px;
    margin: 10px 0;
}


#modify-group {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-bottom: 20px;
}

#modify-group label {
    font-weight: bold;
    margin-bottom: 5px;
}

#modify-group-div textarea {
    width: 100%;
    max-width: 400px;
    min-height: 50px;
    resize: vertical;
    border: 1px solid #ccc;
    border-radius: 4px;
    padding: 8px;
    font-size: 14px;
}
</style>