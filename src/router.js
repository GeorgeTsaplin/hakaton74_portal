import Vue from 'vue'
import Router from 'vue-router'
import Statistics from '@/views/Statistics.vue'

Vue.use(Router)

export default new Router({
	mode: 'history',
	base: process.env.BASE_URL,
	routes: [
		{
			path: '/',
			name: 'home',
			component: Statistics
		},
		{
			path: '/services/:id',
			name: 'services',
			component: () => import('./views/Services.vue')
		},
		{
			path: '/attributes/:id',
			name: 'attributes',
			component: () => import('./views/Attributes.vue')
		}
	]
})
