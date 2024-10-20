import { createRouter, createWebHistory } from 'vue-router'
import Router from '../router/router.js'


const routes = [Router];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: routes
});

export default router;


