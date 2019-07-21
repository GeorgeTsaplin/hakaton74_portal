<template lang="pug">
	#donut-graph
		#donut
		#category-cards

			.card(v-for="category in categories"
				:style="color(category.color)"
				:class="isHighlighted(category)"
				@mouseover="hover(category, true)"
				@mouseout="hover(category, false)")
				.name {{ category.name }}
				.stats
					.percent 35%
					.count 1 143 104

</template>

<script>
	import echarts from 'echarts'
	let onDataReady;

	export default {
		name: "DonutGraph",

		data() {
			return {
				hovered: -1,
			}
		},

		computed: {
			categories() {
				if (this.$store.getters.categories.length > 0)
					onDataReady()

				return this.$store.getters.categories
			}
		},

		methods: {
			color(hex) {
				return `--color: ${hex}`
			},

			hover(category, state) {
				this.hovered = state ? category.id : -1
			},

			isHighlighted(category) {
				return { highlight: category.id === this.hovered }
			}
		},

		mounted() {
			let donut = echarts.init(document.getElementById('donut'));

			donut.showLoading({ text: 'Loading...' });
			onDataReady = () => donut.hideLoading()
			donut.setOption({
				series: [
					{
						type: 'pie',
						radius: ['70%', '90%'],
						avoidLabelOverlap: false,
						label: {
							normal: {
								show: false,
								position: 'center'
							},
							emphasis: {
								show: true,
								textStyle: {
									fontSize: '30',
									fontWeight: 'bold'
								}
							}
						},
						labelLine: {
							normal: {
								show: false
							}
						},
						data: [
							{value: 335, name: '32%', id: 14, itemStyle: { color: '#FFD400' }},
							{value: 310, name: '11%', id: 1, itemStyle: { color: '#5BC3C9' }},
							{value: 234, name: '8%', id: 6, itemStyle: { color: '#FF004C' }},
							{value: 135, name: '6%', id: 4, itemStyle: { color: '#088C66' }},
							{value: 1548, name: '64%', id: 9, itemStyle: { color: '#E6792D' }}
						]
					}
				]
			})

			donut.on('mouseover', params => {
				this.hover({id: params.data.id}, true)
			})

			donut.on('mouseout', params => {
				this.hover({id: params.data.id}, false)
			})
		}
	}
</script>

<style lang="stylus" src="@/assets/stylus/donut-graph.styl"></style>