// import { createApp } from 'vue'
// import './style.css'
// import App from './App.vue'

// createApp(App).mount('#app')



import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import Router from './router/router.js'

const app = createApp(App)

app.use(Router)

app.mount('#app')
