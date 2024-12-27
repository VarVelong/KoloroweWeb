import { createApp } from 'vue'
import App from './App.vue'
import Router from './router'

import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

import "bootstrap"
import "bootstrap/dist/css/bootstrap.min.css"
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import BootstrapVue3 from 'bootstrap-vue-3';

import 'bootstrap-vue-3/dist/bootstrap-vue-3.css';
import 'bootstrap/dist/css/bootstrap.css';


import '@fortawesome/fontawesome-free/css/all.css';
import './style.css'


const app = createApp(App)

app.use(Router)
app.use(BootstrapVue3);

app.component('font-awesome-icon', FontAwesomeIcon);

app.config.globalProperties.$isLoggedIn = () => localStorage.getItem('user') !== null;
app.mount('#app')