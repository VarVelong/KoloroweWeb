import { createRouter, createWebHistory } from 'vue-router';
import Router from '../modules/router.js';

import AuthRouter from '../../src/modules/authorization/AuthRouter.js';
import EmployeeRouter from '../../src/modules/employees/EmployeeRouter.js';
import GalleryRouter from '../../src/modules/imageGallery/GalleryRouter.js';
import OfferRouter from '../../src/modules/offers/OfferRouter.js';
import PostRouter from '../../src/modules/posts/PostsRouter.js';


const routes = [].concat(Router, AuthRouter, EmployeeRouter, GalleryRouter, OfferRouter, PostRouter);

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: routes
});

export default router;


