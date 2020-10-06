<template>
  <nav id="navbar">
    <section id="brand">
      <a href="/">Melea</a>
    </section>
    <section id="links">
      <ul>
        <li><a href="/about">About</a></li>
        <li><a href="/add">Add</a></li>
        <li><a href="/blends">Blends</a></li>
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
  background-color #6f9283
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
        background-color #696d7d

#content
  margin 0 auto
  width 860px

span.heading
  font-weight bold

span.heading.h1
  font-size 36px

span.heading.h2
  font-size 32px

span.heading.h3
  font-size 28px

span.heading.h4
  font-size 24px

span.heading.h5
  font-size 20px

span.heading.h6
  font-size 16px

input
  border 1px solid
  border-color #aaa
  border-radius 2px
  font-size 16px
  padding 2px 4px

button.btn
  border 2px #fff solid
  border-radius 6px
  padding 6px 26px
  color #fff
  font-weight bold
  font-size 14px
  cursor pointer

  &.color-confirm-primary
    background-color #696d7d

  &.color-confirm-secondary
    background-color #cdc6a5

.bg-err
  background-color #db162f
</style>
