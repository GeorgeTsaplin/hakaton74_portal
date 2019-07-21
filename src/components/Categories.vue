<template lang="pug">
	div
		p.header Каталог&nbsp;
			span.blue гос
			span.red услуг

		ul.categories(v-if="categories.length > 0")
			li(v-for="category in categories"
				:style="color(category.color)"
				:class="{active: isActive(category.id)}"
				@click="setCategory(category.id)")
				| {{ category.name }}

		ul.categories(v-else)
			li Сервер не отвечает...

</template>

<script>
	export default {
		name: "Categories",

		computed: {
			categories() {
				return this.$store.getters.categories
			}
		},

		methods: {
			color(hex) {
				return `--color: ${hex}`
			},

			isActive(id) {
				return id === this.$store.getters.selectedCategory
			},

			setCategory(id) {
				this.$store.commit('changeSelectedCategory', id)

				if (this.$store.getters.selectedCategory !== -1) {
					this.$router.push({name: 'services', params: {id}})
				} else {
					this.$router.push({name: 'home'})
				}
			}
		},

		created() {
			this.$store.dispatch('loadCategories')
		}
	}
</script>

<style lang="stylus" src="@/assets/stylus/categories.styl"></style>