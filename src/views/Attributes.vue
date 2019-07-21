<template lang="pug">
	#attributes
		.header {{ trunc(service.name) }}

		.attributes-list(:style="color(category.color)")
			.left
				div(v-for="(attr, letter) in allAttributes")
					.index {{ letter }}
					.items
						.item(v-for="a in attr" @click="add(a)")
							span.text {{ trunc(a) }}
							span.check

			.right
				div(v-for="(attr, letter) in attributes")
					.index {{ letter }}
					.items
						.item(v-for="a in attr" @click="remove(a)").selected
							span.text {{ trunc(a) }}
							span.check


</template>

<script>
	export default {
		name: "Attributes",

		computed: {
			category() {
				return this.$store.getters.category || {name: ''}
			},

			service() {
				return this.$store.getters.service || {name: ''}
			},

			attributes() {
				return this.$store.getters.attributes
			},

			allAttributes() {
				return this.$store.getters.allAttributes
			},
		},

		methods: {
			color(hex) {
				return `--color: ${hex}`
			},

			trunc(str, len = 75) {
				return str.length > len ? `${str.substring(0, len)}...` : str
			},

			add(attr) {
				this.$store.commit('addAttribute', attr)
				this.$store.dispatch('saveAttributes')
			},

			remove(attr) {
				this.$store.commit('removeAttribute', attr)
				this.$store.dispatch('saveAttributes')
			},
		},

		created() {
			if (this.$store.getters.selectedService === -1) {
				this.$router.replace({name: 'home'})
			}

			this.$store.dispatch('loadAttributes')
		}
	}
</script>

<style lang="stylus" src="@/assets/stylus/attributes.styl"></style>