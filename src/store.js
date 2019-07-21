import Vue from 'vue'
import Vuex from 'vuex'
import api from '@/api'

Vue.use(Vuex)

export default new Vuex.Store({
	state: {
		categories: [],
		statistics: [],
		services: [],
		attributes: [],
		allAttributes: [],

		selectedCategory: -1,
		selectedService: -1,
	},
	getters: {
		categories: state => state.categories,
		selectedCategory: state => state.selectedCategory,
		selectedService: state => state.selectedService,

		category: state => state.categories.find(item => item.id === state.selectedCategory),
		service: state => state.services.find(item => item.id === state.selectedService),

		services: state => state.services
			.filter(item => item.category === state.selectedCategory)
			.map(item => ({letter: item.name[0], service: item}))
			.reduce((h, obj) => Object.assign(h, { [obj.letter]:( h[obj.letter] || [] ).concat(obj.service) }), {}),

		attributes: state => (state.attributes || [])
			.sort((a, b) => a.localeCompare(b))
			.map(item => ({letter: item[0], service: item}))
			.reduce((h, obj) => Object.assign(h, { [obj.letter]:( h[obj.letter] || [] ).concat(obj.service) }), {}),

		allAttributes: state => state.allAttributes
			.sort((a, b) => a.localeCompare(b))
			.filter(item => state.attributes.indexOf(item) === -1)
			.map(item => ({letter: item[0], service: item}))
			.reduce((h, obj) => Object.assign(h, { [obj.letter]:( h[obj.letter] || [] ).concat(obj.service) }), {}),


	},
	mutations: {
		updateCategories(state, categories) {
			state.categories = categories
		},

		updateStatistics(state, statistics) {
			state.statistics = statistics
		},

		updateServices(state, services) {
			state.services = services
		},

		updateAttributes(state, attributes) {
			console.log('updateAttributes', attributes)
			state.attributes = (attributes.attributes || []).map(item => item.attribute)
		},

		updateAllAttributes(state, attributes) {
			console.log('updateAllAttributes', attributes)
			state.allAttributes = attributes.map(item => item.attribute)
		},

		changeSelectedCategory(state, id) {
			state.selectedCategory = id === state.selectedCategory ? -1 : id
		},

		changeSelectedService(state, id) {
			state.selectedService = id === state.selectedService ? -1 : id
		},

		addAttribute(state, attr) {
			state.attributes.push(attr)
			state.allAttributes = state.allAttributes
				.filter(item => item !== attr)
		},

		removeAttribute(state, attr) {
			state.allAttributes.push(attr)
			state.attributes = state.attributes
				.filter(item => item !== attr)
		},
	},
	actions: {
		async loadCategories({commit}) {
			commit('updateCategories', await api.categories())
		},

		async loadServices({commit}) {
			commit('updateServices', await api.services())
		},

		async loadAttributes({commit, state}) {
			commit('updateAllAttributes', await api.allAttributes())
			commit('updateAttributes', await api.attributes(state.selectedService))
		},

		async saveAttributes({state}) {
			await api.saveAttributes(state.selectedService, state.attributes)
		},

		async loadStatistics({commit}) {
			commit('updateStatistics', await api.statistics())
		},
	}
})
