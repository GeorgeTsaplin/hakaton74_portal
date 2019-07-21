import axios from 'axios'

let host = 'http://192.168.43.58:5000/api'

const api = axios.create({
	baseURL: host,
	headers: {
		'X-Requested-With': 'XMLHttpRequest'
	},
})

export default {
	categories() {
		return api.get(`${host}/categories`).then(res => res.data)
	},

	services() {
		return api.get(`${host}/services`).then(res => res.data)
	},

	attributes(id) {
		return api.get(`${host}/services/${id}`).then(res => res.data || {})
	},

	allAttributes() {
		return api.get(`${host}/attributes`).then(res => res.data)
	},

	statistics() {
		return api.get(`${host}/categories`).then(res => res.data)
	},

	saveAttributes(id, attributes) {
		attributes = attributes.map(attribute => ({attribute}))
		console.log({attributes})
		return api.post(`${host}/services/${id}`, {attributes})
	}
}