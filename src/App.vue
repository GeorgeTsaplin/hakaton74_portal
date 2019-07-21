<template lang="pug">
	#app
		Header

		.container-fluid
			.row
				.col-3#categories
					Categories

				.col-9#content
					router-view

</template>

<script>
	import Header from "@/components/Header";
	import Categories from "@/components/Categories";

	export default {
		components: {Categories, Header}
	}
</script>

<style src="@/assets/bootstrap-grid.min.css"></style>
<style lang="stylus" src="@/assets/stylus/main.styl"></style>