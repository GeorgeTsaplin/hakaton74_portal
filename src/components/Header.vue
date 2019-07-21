<template lang="pug">
	#header.container-fluid
		.row
			.col-3#logo
				img(src="../assets/kot.svg")
			.col-6#search-main
				.input-group
					input(placeholder="Поиск")
					.search
						.search-image-wrapper
							.icon
			.col-3#user
				.avatar
					img(src="../assets/usr.png")
				.name Савельев Игорь Павлович
				.settings
					.cog
</template>

<script>
	export default {
		name: "Header"
	}
</script>

<style lang="stylus" src="@/assets/stylus/header.styl"></style>