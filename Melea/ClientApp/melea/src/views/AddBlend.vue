<template lang="pug">
.add-blend
  .add-blend-content
    .header
      span.heading.h3 Oil {{ currentStep }}
    FilterableSelect.oil-select(:options="essentialOils"
      @option-selected="assignCurrentOil($event)")
    button.btn.color-confirm-primary Done
    button.btn.color-confirm-secondary(@click="addNewOil") Add oil
    div.progress-container
      ul.blend-progress
        li(v-for="i in oilNum" @click="currentStep = i")
          span.progress-dash(:class="{'active': i === currentStep}")
</template>

<script lang="ts">
// This page will eventually be a wizard
import { Options, Vue } from 'vue-class-component';
import FilterableSelect from '@/components/FilterableSelect.vue';
import { EssentialOil } from '@/types';
import { getOils } from '@/lib/data';

@Options({
  components: { FilterableSelect },
})

export default class AddBlend extends Vue {
  oilNum = 1;

  currentStep = 1;

  selections: Array<any> = [];

  currentOil = '';

  essentialOils: Array<string> = [];

  async created() {
    const resp: Array<EssentialOil> = await getOils();
    this.essentialOils = resp.map((o: EssentialOil) => o.name);
  }

  addNewOil() {
    if (this.currentOil.trim() !== '') {
      this.oilNum += 1;
      this.currentStep = this.oilNum;
      this.selections.push(this.currentOil);
      this.currentOil = '';
    }
  }

  assignCurrentOil(e: string) {
    this.currentOil = e;
  }
}
</script>

<style scoped lang="stylus">
.add-blend
  display flex
  flex-direction row
  justify-content center

.oil-select
  width 480px
  margin-bottom 12px

.header
  text-align center
  margin 18px 0

.progress-container
  display flex
  justify-content center

.blend-progress
  padding 0
  margin 0
  list-style-type none

  li
    display inline-block
    margin 0 1px
    cursor pointer

    .progress-dash
      display inline-block
      height 4px
      width 24px
      background-color #d8d8d8

      &.active
        background-color #5FC1A7
</style>
