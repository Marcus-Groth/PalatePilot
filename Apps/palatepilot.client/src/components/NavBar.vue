<script setup>
import authService from '@/services/authService';
import { useRouter }   from 'vue-router';
const router = useRouter();

function handleLogoutButton(){
  authService.logout("jwt")
  router.push('/login')
}

</script>

<template>

<nav class="navbar is-success is-flex is-align-items-center is-justify-content-space-between px-4 is-fixed-top" role="navigation" aria-label="main navigation">
    <div class="navbar-start">
        <div class="navbar-item">
            <button @click="handleLogoutButton" class="button">Logout</button>
        </div>
    </div>
    
    <div class="navbar-left">
        <div class="navbar-item">
            <div class="cart container">
                <font-awesome-icon class="icon  has-text-white is-medium" icon="fa-solid fa-cart-shopping" />
                <span class="cart-badge has-background-link">4</span>
            </div>
        </div>
    </div> 
</nav>                
</template>

<style>

.cart{
    position: relative;
}

.cart-badge{
    color: white;
    border-radius: 50%;
    padding: 0.05em 0.5em;
    font-size: 0.65rem;
    position: absolute;
    top: -0.5em;
    right: -0.5em;
}







</style>
  
