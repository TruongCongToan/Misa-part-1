<template>
    <div id="header">
            <div class="header-left-icon"></div>
        <div class="header-title">
            <select class="header-select" name="" id="">
                <option value="">TẬP ĐOÀN VINGROUP</option>
                <option value="">CÔNG TY MISA</option>
                <option value="">TẬP ĐOÀN HÒA PHÁT</option>
                <option value="">NGÂN HÀNG VPBANK</option>
            </select>
        </div>
          <div class="header-ring-icon"></div>
        <div class="header-user">
            <img src="../../assets/img/default-avatar.jpg" alt="avatar" class="user-avatar">
            <div class="user-name">
                <span>Trương Công Toàn</span>
            </div>
            <div class="header-right-icon"></div>
        </div>
    </div>
</template>

<style scoped>
#header {
    border: 1px solid #dedede;
    position: absolute;
    left:200px;
    right:0;
    height: 60px;
    top:0;
    display: flex;
    justify-content: space-between;
    align-items: center;
    /* background-color: #4cff00; */
}

.header-select {
    border-color: transparent;
    font-size: 1.2rem;
    font-weight: bold;
    margin-left: 30px;
    outline: none;
}

.header-user {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-right: 20px;
}

.user-avatar {
    width: 25px;
    height:25px;
    border-radius:50%;
}

.user-name > span{
    font-size: 1.2rem;
    margin: auto 16px;
}

.header-right-icon{
 position: absolute;
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -1129px -365px;
	width: 14px;
	height: 8px;
    top: 25px;
    right: 16px;
    cursor: pointer;
}
 .header-ring-icon{
      position: absolute;
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -788px -30px;
	width: 22px;
	height: 21px;
    top: 20px;
    right: 250px;
    cursor: pointer;
 }
 .header-left-icon{
       background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -847px -35px;
	width: 16px;
    height: 14px;
    position: absolute;
    left: 12px;
    top:20px;
    cursor: pointer;
 }
</style>
