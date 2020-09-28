<template>
  <div class="home">
    <BlendCard :name="blend.name" :volumes="blend.volumes" />
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { getJson } from '@/lib/req';
import { Blend } from '@/types';
import BlendCard from '@/components/BlendCard.vue';

@Options({
  components: {
    BlendCard,
  },
})

export default class Home extends Vue {
  blend: Blend = { id: 0, name: '', volumes: [] };

  async created() {
    this.blend = await getJson('/api/blends/random');
    this.blend.volumes = this.blend.volumes.sort((o, t) => t.drops - o.drops);
  }
}
</script>
