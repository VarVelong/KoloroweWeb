import { createRouter, createWebHistory } from 'vue-router'
import Router from '../modules/router.js'


const routes = [].concat(Router);

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: routes
});

export default router;


