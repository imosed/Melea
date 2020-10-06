<template lang="pug">
.card-component
  .card-header {{ name }}
  .card-body
    ul
      template(v-for="(volume, i) in volumes" v-bind:key="i")
        li {{ volume.drops }} drops of {{ volume.oil.name }}
  .card-footer
    slot(name="card-footer")
</template>

<script lang="ts">
import { Vue } from 'vue-class-component';
import { Volume } from '@/types';
import { Prop } from 'vue-property-decorator';

export default class BlendCard extends Vue {
  @Prop()
  name!: string;

  @Prop()
  volumes: Array<Volume> = [];
}
</script>

<style scoped lang="stylus">
.card-component
  display flex
  flex-direction column
  justify-content space-between
  color #F0DCCA
  background-color #6F9283
  min-height 320px
  padding 40px 48px

.card-header
  font-size 42px
  font-family sans-serif
  font-weight bold
  flex 1

.card-body
  font-size 20px
  flex 4

.card-footer
  flex 1

ul
  list-style-type none
  padding 0
  margin 0
</style>
