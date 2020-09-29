<template lang="pug">
  .accordion-component
    .accordion-control(@click="toggleAccordion")
      | {{title}}
      .accordion-arrow(:class="{'accordion-down': !extended}")
    .accordion-content(:class="{'active': extended, 'inactive': !extended}")
      .accordion-header
        slot(name="accordion-header")
      .accordion-body
        slot(name="accordion-body")
      .accordion-footer
        slot(name="accordion-footer")
</template>

<script lang="ts">
import { Vue } from 'vue-class-component';
import { Prop } from 'vue-property-decorator';

export default class Accordion extends Vue {
  @Prop()
  title!: string;

  extended = false;

  toggleAccordion() {
    this.extended = !this.extended;
  }
}
</script>

<style lang="stylus" scoped>
.accordion-control
  display flex
  justify-content space-between
  background-color #035A7C
  cursor pointer
  color #fff
  font-weight bold
  font-size 18px
  padding 6px 10px
  border-radius 3px 3px 0 0
  border 1px solid
  border-color #cfcfcf #cfcfcf #D1E2D0 #cfcfcf

  .accordion-arrow
    margin auto 0
    background-color: #fff;
    height: 10px; width: 11px;
    clip-path: polygon(50% 0%, 0% 100%, 100% 100%);
    transition transform 380ms cubic-bezier(.68,-0.55,.27,1.55)

    &.accordion-down
      transform rotate(-180deg)

.accordion-content
  overflow hidden
  border-radius 0 0 3px 3px
  border #cfcfcf solid
  border-width 0 1px 1px 1px
  transition height 0.25s ease-in, padding 0.25s ease-in
  &.active
    height 158px
    padding-top 16px
    padding-bottom 16px

  &.inactive
    height 0
    padding-top 0
    padding-bottom 0

.accordion-header
  margin-bottom 4px
  padding 4px 20px

.accordion-body
  display flex
  flex-direction row
  justify-content space-between
  padding 6px 20px

.accordion-footer
  border-top #ededed 1px solid
  margin-top 10px
  padding 8px 20px
</style>
