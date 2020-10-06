<template lang="pug">
.add-blend
  .add-blend-content
    .header
      span.heading.h3 Oil {{ currentStep }}
    .form-group
      .input-controls
        FilterableSelect.oil-select(:options="essentialOils"
          :val="currentOil"
          @option-selected="assignCurrentOil($event)")
        input(type="number"
          @change="assignCurrentDrops($event)"
          v-model="currentDrops")
      .button-group
        button.btn.color-confirm-primary Done
        button.btn.color-confirm-secondary(@click="addNewOil") Add oil
    div.progress-container
      ul.blend-progress
        li(v-for="i in numberOfOils" @click="jumpToStep(i)")
          span.progress-dash(:class="{'active': i === currentStep}")
</template>

<script lang="ts">
// This page will eventually be a wizard
import { Options, Vue } from 'vue-class-component';
import FilterableSelect from '@/components/FilterableSelect.vue';
import { BlendComponent, EssentialOil } from '@/types';
import { getOils } from '@/lib/data';

@Options({
  components: { FilterableSelect },
})

export default class AddBlend extends Vue {
  numberOfOils = 1;

  currentStep = 1;

  selections: Array<BlendComponent> = [];

  currentOil = '';

  currentDrops = 0;

  stash: BlendComponent = { oilName: '', drops: 0 };

  essentialOils: Array<string> = [];

  async created() {
    const resp: Array<EssentialOil> = await getOils();
    this.essentialOils = resp.map((o: EssentialOil) => o.name);
  }

  addNewOil() {
    if (this.currentOil.trim() !== '') {
      this.numberOfOils += 1;
      this.currentStep = this.numberOfOils;
      this.selections.push({ oilName: this.currentOil, drops: this.currentDrops });
      const selectedNames = this.selections.map((s: BlendComponent) => s.oilName);
      this.essentialOils = this.essentialOils.filter((o: string) => !selectedNames.includes(o));
      this.currentOil = '';
      this.currentDrops = 0;
      this.stash = { oilName: '', drops: 0 };
    }
  }

  assignCurrentOil(e: string) {
    if (e !== '') {
      this.currentOil = e;
      if (this.currentStep === this.numberOfOils) {
        this.stash.oilName = this.currentOil;
      }
    }
  }

  assignCurrentDrops(e: Event) {
    const v = Number((e.target as HTMLInputElement).value);
    if (!Number.isNaN(v) && v > 0) {
      this.currentDrops = v;
      if (this.currentStep === this.numberOfOils) {
        this.stash.drops = this.currentDrops;
      }
    }
  }

  jumpToStep(num: number) {
    this.currentStep = num;
    if (num !== this.numberOfOils) {
      this.currentOil = this.selections[num - 1].oilName;
      this.currentDrops = this.selections[num - 1].drops;
    } else {
      this.currentOil = this.stash.oilName;
      this.currentDrops = this.stash.drops;
    }
  }
}
</script>

<style scoped lang="stylus">
.add-blend
  display flex
  flex-direction row
  justify-content center

.add-blend-content
  height 400px
  display flex
  flex-direction column
  justify-content space-between

.oil-select
  width 480px

.header
  text-align center
  margin 18px 0

.input-controls
  display flex
  justify-content space-between
  margin-bottom 20px

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
      background-color #CDC6A5

      &.active
        background-color #696D7D
</style>
