<script setup lang="ts">
</script>

<template>
  <!-- Section -->
  <section class="hero is-fullheight">
    <div class="hero-body has-text-centered">
      <div class="container">
        <div class="columns">
          <!-- Header -->
          <header class="column mb-5">
            <h1 class="title">Sign up today</h1>
          </header>
          <!-- Main content -->
          <main class="column">
            <form>
              <!-- Username field -->
              <div class="field">
                <div class="control">
                  <input v-model="user.username" class="input is-medium is-success" type="text" placeholder="Username">
                </div>
              </div>

              <!-- Email field -->
              <div class="field">
                <div class="control">
                  <input v-model="user.email" class="input is-medium is-success" type="email" placeholder="Email">
                </div>
              </div>
              
              <!-- Password field -->
              <div class="field mb-5">
                <div class="control">
                  
                  <input v-model="user.password" class="input is-medium is-success" type="password" placeholder="Password">
                </div>
              </div>
              <!-- Login button -->
              <div class="field">
                <div class="control">
                  <button class="button is-block is-fullwidth is-medium is-success">Login</button>
                </div>
              </div>
            </form>
          </main>
          <!-- Footer -->
          <footer class="column">
            <div>
              <!-- Footer links -->
              <div class="mb-2">
                <a class="is-size-6" href="#">Already have an account?</a>
              </div>
            </div>
          </footer>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
</style>
