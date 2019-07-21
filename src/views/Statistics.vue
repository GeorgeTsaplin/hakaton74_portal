<template lang="pug">
	#statistics
		.header Гистограмма прогноза оказания госуслуг в разбивке по категориям
		DonutGraph

		.header Временной график предоставления услуг
		LineGraph
</template>

<script>
	import DonutGraph from "@/components/DonutGraph";
	import LineGraph from "@/components/LineGraph";
	export default {
		name: "Statistics",
		components: {LineGraph, DonutGraph}
	}
</script>

<style lang="stylus">
	#statistics
		#donut
			width 350px
			height 350px
</style>