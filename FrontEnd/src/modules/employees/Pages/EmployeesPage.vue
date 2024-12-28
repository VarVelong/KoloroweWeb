<template>

    <body>

        <ul>
            <li>
                <div>
                    <h2>Dyrekcja:</h2>
                    <div v-if="!isEditing.principals">{{employee.principals}}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.principals" @click="isEditing.principals = true">edit</button>
                    <input v-model="employee.principals" v-if="isEditing.principals"/>
                    <button v-if="isEditing.principals" @click="saveEmployee('Principals', employee.principals); isEditing.principals = false">save</button>
                    <button v-if="isEditing.principals" @click="isEditing.principals = false">cancel</button>
                </div>
                <div>
                    <h2>Grupa Czerwona:</h2>
                    <div v-if="!isEditing.groupRed">{{employee.groupRed}}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.groupRed" @click="isEditing.groupRed = true">edit</button>
                    <input v-model="employee.groupRed" v-if="isEditing.groupRed"/>
                    <button v-if="isEditing.groupRed" @click="saveEmployee('GroupRed', employee.groupRed); isEditing.groupRed = false">save</button>
                    <button v-if="isEditing.groupRed" @click="isEditing.groupRed = false">cancel</button>
                </div>
                <div>
                    <h2>Grupa Żółta:</h2>
                    <div v-if="!isEditing.groupYellow">{{employee.groupYellow}}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.groupYellow" @click="isEditing.groupYellow = true">edit</button>
                    <input v-model="employee.groupYellow" v-if="isEditing.groupYellow"/>
                    <button v-if="isEditing.groupYellow" @click="saveEmployee('GroupYellow', employee.groupYellow); isEditing.groupYellow = false">save</button>
                    <button v-if="isEditing.groupYellow" @click="isEditing.groupYellow = false">cancel</button>
                </div>
                <div>
                    <h2>Grupa Niebieska:</h2>
                    <div v-if="!isEditing.groupBlue">{{employee.groupBlue}}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.groupBlue" @click="isEditing.groupBlue = true">edit</button>
                    <input v-model="employee.groupBlue" v-if="isEditing.groupBlue"/>
                    <button v-if="isEditing.groupBlue" @click="saveEmployee('GroupBlue', employee.groupBlue); isEditing.groupBlue = false">save</button>
                    <button v-if="isEditing.groupBlue" @click="isEditing.groupBlue = false">cancel</button>
                </div>
                <div>
                    <h2>Grupa Zielona:</h2>
                    <div v-if="!isEditing.groupGreen">{{employee.groupGreen}}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.groupGreen" @click="isEditing.groupGreen = true">edit</button>
                    <input v-model="employee.groupGreen" v-if="isEditing.groupGreen"/>
                    <button v-if="isEditing.groupGreen" @click="saveEmployee('GroupGreen', employee.groupGreen); isEditing.groupGreen = false">save</button>
                    <button v-if="isEditing.groupGreen" @click="isEditing.groupGreen = false">cancel</button>
                </div>
                <div>
                    <h2>Specjaliści:</h2>
                    <div v-if="!isEditing.specialists">{{employee.specialists}}</div>
                    <button v-if="this.$isLoggedIn() && !isEditing.specialists" @click="isEditing.specialists = true">edit</button>
                    <input v-model="employee.specialists" v-if="isEditing.specialists"/>
                    <button v-if="isEditing.specialists" @click="saveEmployee('Specialists', employee.specialists); isEditing.specialists = false">save</button>
                    <button v-if="isEditing.specialists" @click="isEditing.specialists = false">cancel</button>
                </div>
            </li>
        </ul>
    </body>
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
div {
  background-color: #FFF9C4; 
  border: 3px solid #FFD54F;
  border-radius: 15px;
  padding: 20px;
  margin: 30px auto;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
  text-align: center; 
}

h2 {
  color: #FF6F61; 
  font-size: 2em;
  margin-bottom: 10px;
  text-shadow: 1px 1px #FFD9E8;
}
</style>