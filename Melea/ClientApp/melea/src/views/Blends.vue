<template lang="pug">
.blends
  div(v-for="(blend, i) in allBlends" v-bind:key="i")
    BlendCard(:name="blend.name" :volumes="blend.volumes")
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { getJson } from '@/lib/req';
import { Blend } from '@/types';
import BlendCard from '@/components/BlendCard.vue';

@Options({
  components: { BlendCard },
})

export default class Blends extends Vue {
  allBlends: Array<Blend> = [];

  async created() {
    this.allBlends = await getJson('/api/blends/list');
  }
}
</script>

<style scoped lang="stylus">
.blends
  display grid
  grid-template-columns 1fr 1fr
  grid-gap 16px
</style>
