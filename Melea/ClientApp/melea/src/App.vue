<template>
  <nav id="navbar">
    <section id="brand">
      <a href="/">Melea</a>
    </section>
    <section id="links">
      <ul>
        <li><a href="/blends">Blends</a></li>
        <li><a href="/about">About</a></li>
      </ul>
    </section>
  </nav>
  <div id="content">
    <router-view/>
  </div>
</template>

<style lang="stylus">
@import url('https://fonts.googleapis.com/css2?family=Palanquin+Dark:wght@500&display=swap')

body
  padding 0
  margin 0
  font-family sans-serif

#navbar
  display flex
  flex-direction row
  justify-content space-between
  background-color #24B0C6
  margin-bottom 12px
  color #fff

  a
    text-decoration none
    color #fff

  #brand
    font-family "Palanquin Dark"
    letter-spacing -1px
    display flex
    align-items center
    font-weight bold
    margin 0 12px
    font-size 28px

  #links ul
    display flex
    flex-direction row
    list-style-type none
    padding 0
    margin 0

    a
      display inline-block
      padding 20px 12px
      margin 0 4px

      &:hover
        background-color #09899c

#content {
  margin 0 auto
  width 860px
}

input
  border-radius 0
  border 1px solid
  border-color #aaa
  padding 0 8px
  border-radius 2px

button.btn
  border 2px #fff solid
  border-radius 6px
  background-color brown
  padding 6px 26px
  color #fff
  font-weight bold
  font-size 14px
  cursor pointer

.bg-err
  background-color #DA4B6F
</style>
