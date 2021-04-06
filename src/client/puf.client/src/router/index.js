import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import yazarlarigor from '../views/writer/yazarlari-gor.vue'
import yazarol from '../views/writer/yazar-ol.vue'
import yazargirisi from '../views/writer/yazar-girisi.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/writer/yazarlari-gor',
    name: 'yazarlari-gor',
    component: yazarlarigor
  },
  {
    path: '/writer/yazar-ol',
    name: 'yazar-ol',
    component: yazarol
  },
  {
    path: '/writer/yazar-girisi',
    name: 'yazar-girisi',
    component: yazargirisi
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
