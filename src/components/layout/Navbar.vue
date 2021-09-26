<template>
    <div id="navbar">
        <div class="logo-box">
            <div class="sidebar"></div>
            <div class="logo"></div>
        </div>
        <div class="navbar-box">
            <a class="navbar-item">
                <div class="icon-dashboard"></div>
                <div class="navbar-text">Tổng quan</div>
            </a>
           
            <a class="navbar-item">
                <div class="icon-tien-mat"></div>
                <div class="navbar-text">Tiền mặt</div>
            </a>
            <a class="navbar-item" href="#">
                <div class="icon-tien-gui"></div>
                <div class="navbar-text">Tiền gửi</div>
            </a>
            <a class="navbar-item">
                <div class="icon-mua-hang"></div>
                <div class="navbar-text">Mua hàng</div>
            </a>
            <a class="navbar-item">
                <div class="icon-ban-hang"></div>
                <div class="navbar-text">Bán hàng</div>
            </a>
            <a class="navbar-item">
                <div class="icon-quan-ly-don"></div>
                <div class="navbar-text">Quản lý đơn</div>
            </a>
            <a class="navbar-item">
                <div class="icon-kho"></div>
                <div class="navbar-text">Kho</div>
            </a>
            <a class="navbar-item">
                <div class="icon-cong-cu"></div>
                <div class="navbar-text">Công cụ dụng cụ</div>
            </a>
            <a class="navbar-item">
                <div class="icon-tai-san"></div>
                <div class="navbar-text">Tài sản cố định</div>
            </a>
            <a class="navbar-item">
                <div class="icon-thue"></div>
                <div class="navbar-text">Thuế</div>
            </a>
            <a class="navbar-item">
                <div class="icon-gia-thanh"></div>
                <div class="navbar-text">Giá thành</div>
            </a>
            <a class="navbar-item">
                <div class="icon-tong-hop"></div>
                <div class="navbar-text">Tổng hợp</div>
            </a>
            <a class="navbar-item">
                <div class="icon-ngan-sach"></div>
                <div class="navbar-text">Ngân sách</div>
            </a>
            <a class="navbar-item">
                <div class="icon-bao-cao"></div>
                <div class="navbar-text">Báo cáo</div>
            </a>
            <a class="navbar-item">
                <div class="icon-phan-tich"></div>
                <div class="navbar-text">Phân tích tài chính</div>
            </a>
        </div>
    </div>
</template>

<style scoped>
    #navbar {
    width: 200px;
    height: 100vh;
    border-right: 1px solid #dedede;
    background-color: rgb(45, 46, 46); 
    /* color: white; */
}


.logo-box{
    display: flex;
    align-items: center;
    height: 60px;
    width: 100%;
    cursor: pointer;
}

    .logo-box .sidebar {
    
        flex-shrink: 0;
        background-size: contain;
        margin-left: 16px;
        background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -428px -92px;
        width: 16px;
        height: 16px;
        
    }

    .logo-box .logo {
       
        width:100%;
        height:33px;
        flex-shrink: 0;
        background-image: url('../../assets/img/Logo_Module_TiengViet_White.66947422.svg');
        background-size:contain;
        background-repeat: no-repeat;
        font-weight: bold;
        position: absolute;
        left: 45px;
        
       
    }
    
.navbar-box .navbar-item{
    display: flex;
    align-items: center;
    height: 44px;
    padding: 0;

}

    .navbar-box .navbar-item:hover{
        background-color: #dedede;
        cursor: pointer;
    }

    .navbar-item .navbar-icon {
        margin-left: 16px;
        width: 20px;
        height: 20px;
        background-size: contain;
        background-repeat: no-repeat;
        background-position: center;
    }

.navbar-item .navbar-text{
    margin-left: 50px;
    color: white;
}

a.navbar-item:hover{
    cursor: pointer;
}
a.navbar-item:active{
    background-color: aquamarine;
}
.icon-dashboard {
    background: url('../../assets/img/Sprites.64af8f61.svg')  no-repeat -33px -1587px;
	width: 18px;
	height: 20px;
    position: absolute;
    left: 10px;
}

.icon-tien-mat {
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -78px -1588px;
	width: 14px;
	height: 18px;
    position: absolute;
    left: 10px;
}
.icon-tien-gui{
    background: url('../../assets/img/Sprites.64af8f61.svg')no-repeat -121px -1590px;
	width: 16px;
	height: 16px;
    position: absolute;
    left: 10px;
}
.icon-mua-hang{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -165px -1589px;
	width: 16px;
	height: 18px;
    position: absolute;
    left: 10px;
}
.icon-ban-hang{
    background: url('../../assets/img/Sprites.64af8f61.svg')  no-repeat -206px -1588px;
	width: 20px;
	height: 18px;
    position: absolute;
    left: 10px;
}
.icon-quan-ly-don{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -254px -1589px;
	width: 14px;
	height: 17px;
    position: absolute;
    left: 10px;
}
.icon-kho{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -294px -1589px;
	width: 18px;
	height: 17px;
    position: absolute;
    left: 10px;
}
.icon-cong-cu{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -339px -1590px;
	width: 18px;
	height: 17px;
    position: absolute;
    left: 10px;
}
.icon-tai-san{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -382px -1589px;
	width: 17px;
	height: 18px;
    position: absolute;
    left: 10px;
}
.icon-thue{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -427px -1591px;
	width: 16px;
	height: 16px;
    position: absolute;
    left: 10px;
}
.icon-gia-thanh{
    background: url('../../assets/img/Sprites.64af8f61.svg')  no-repeat -471px -1590px;
	width: 17px;
	height: 17px;
    position: absolute;
    left: 10px;
}
.icon-tong-hop{
    background: url('../../assets/img/Sprites.64af8f61.svg')no-repeat -514px -1590px;
	width: 15px;
    height: 16px;;
    position: absolute;
    left: 10px;
}
.icon-ngan-sach{
    background: url('../../assets/img/Sprites.64af8f61.svg')  no-repeat -340px -1662px;
	width: 14px;
    height: 18px;;
    position: absolute;
    left: 10px;
}
.icon-bao-cao{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -552px -1593px;
	width: 14px;
	height: 13px;
    position: absolute;
    left: 10px;
}
.icon-phan-tich{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -251px -1667px;
	width: 17px;
    height: 14px;;
    position: absolute;
    left: 10px;
}
.icon-footer-cham{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -568px -30px;
	width: 30px;
    height: 30px;;
    position: absolute;
    right: 68px;
    top: 25px;
}
</style>
