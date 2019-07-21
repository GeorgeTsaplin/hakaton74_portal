<template lang="pug">
	#services
		.header {{ category.name }}

		#index(v-if="isNotEmpty(services)" :style="color(category.color)")
			div(v-for="(service, letter) in services")
				.letter {{ letter }}
				.items
					div(v-for="sv in service"
						@click="setService(sv.id)") {{ sv.name }}

		div(v-else) К сожалению, тут пусто :(
</template>

<script>
	export default {
		name: "Services",

		computed: {
			category() {
				return this.$store.getters.category || {name: ''}
			},

			services() {
				return this.$store.getters.services
			},
		},

		methods: {
			color(hex) {
				return `--color: ${hex}`
			},

			isNotEmpty(service) {
				return Object.keys(service).length > 0 && service.constructor === Object
			},

			setService(id) {
				this.$store.commit('changeSelectedService', id)

				if (this.$store.getters.selectedService !== -1) {
					this.$router.push({name: 'attributes', params: {id}})
				} else {
					this.$router.push({name: 'home'})
				}
			},
		},

		created() {
			if (this.$store.getters.selectedCategory === -1) {
				this.$router.replace({name: 'home'})
			}

			this.$store.dispatch('loadServices')
		}
	}
</script>

<style lang="stylus">
	#services
		#index
			margin-left 5px

			.letter
				font-weight bold
				font-size 24px
				line-height 29px

			.items
				margin-left 3px
				margin-bottom 25px
				line-height 35px
				text-decoration-line underline
				color var(--color)
				cursor pointer

</style>