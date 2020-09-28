<template>
  <div class="filterable-select-component">
    <input
      type="text"
      v-model="inp"
      :class="{'extended': extended}"
      @focus="extended = true"
      @keyup="filterOptions(inp)"
      ref="filterBox"
    />
    <ul
      class="fs-options" v-show="extended" :class="{'extended': extended}" ref="suggestions">
      <template v-for="(opt, i) in opts" v-bind:key="i">
        <li @click="handleClick(opt)">{{opt}}</li>
      </template>
    </ul>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { Watch } from 'vue-property-decorator';

@Options({
  props: {
    options: Array,
  },
})

export default class FilterableSelect extends Vue {
  inp = '';

  extended = false;

  options!: Array<string>;

  opts: Array<string> = [];

  private lostFocus() {
    if (!this.$el.contains(document.activeElement) && this.extended) {
      this.extended = false;
    }
  }

  mounted() {
    const suggBox = this.$refs.suggestions as HTMLUListElement;
    const filterInp = this.$refs.filterBox as HTMLInputElement;
    suggBox.style.width = `${filterInp.clientWidth}px`;

    document.addEventListener('click', this.lostFocus);
  }

  beforeUnmount() {
    document.removeEventListener('click', this.lostFocus);
  }

  filterOptions(criteria: string) {
    if (criteria.length > 0) {
      this.opts = this.options.filter(
        (e: string) => e.toLowerCase().startsWith(criteria.toLowerCase()),
      );
    } else {
      this.opts = this.options;
    }
  }

  handleClick(val: string) {
    this.inp = val;
    this.extended = false;
  }

  @Watch('options')
  onPropertyChanged(value: Array<string>) {
    this.opts = value;
  }
}
</script>

<style lang="stylus" scoped>
.fs-options
  position absolute
  background-color #fff
  max-height 440px
  list-style-type none
  padding 0
  margin 0
  border 1px solid
  border-color #777
  overflow-y scroll

  &.extended
    border-color #c6c6c6 #777 #777 #777

  li
    padding 8px
    cursor pointer

    &:hover
      background-color #cfcfcf

.extended
  border-color #777 #777 #c6c6c6 #777
</style>
