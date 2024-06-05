import { createRouter, createWebHistory } from 'vue-router'
import AuthLayout from '@/layouts/AuthLayout.vue'
import HomeLayout from '@/layouts/HomeLayout.vue'
import BattleRoomLayout from '@/layouts/BattleRoomLayout.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/auth',
      name: 'auth',
      component: AuthLayout
    },
    {
      path: '/',
      name: 'home',
      component: HomeLayout
    },
    {
      path: '/battle/:id',
      component: BattleRoomLayout
    },
  ]
})

export default router
