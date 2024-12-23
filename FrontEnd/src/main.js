import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import Router from './router'

const app = createApp(App)

app.use(Router)

app.config.globalProperties.$isLoggedIn = () => localStorage.getItem('user') !== null;
app.mount('#app')
