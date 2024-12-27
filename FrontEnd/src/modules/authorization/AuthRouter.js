import AdminPage from "./Pages/AdminPage.vue";
import Login from "./Pages/Login.vue";
import Register from "./Pages/Register.vue";

export default[
        {
            path: '/login',
            name: 'login',
            component: Login
        },
    
        {
            path: '/register',
            name: 'register',
            component: Register
        },
    
        {
            path: '/adminpage',
            name: 'adminpage',
            component: AdminPage
        }
]