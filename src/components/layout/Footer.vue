<template>
    <div class="footer">
        <div class="number-customer">
            <p>Tổng số <span  style="color:red;font-weight:bold;"> 1035</span> bản ghi</p>
        </div>
         <!-- @change="filterData" -->
           <select id="select-paging-number"> 
                <option value="allPosition">10 bản ghi trên 1 trang</option>
                <option value="3700cc49-55b5-69ea-4929-a2925c0f334d">20 bản ghi trên 1 trang</option>
                <option value="25c6c36e-1668-7d10-6e09-bf1378b8dc91">30 bản ghi trên 1 trang</option>
                <option value="148ed882-32b8-218e-9c20-39c2f00615e8">50 bản ghi trên 1 trang</option>
            </select>
        <div class="switch-page">
            <img src="../../assets/icon/btn-firstpage.svg" alt="first-page-btn" class="first-page-btn">
            <img src="../../assets/icon/btn-prev-page.svg" alt="prev-page-btn" class="first-page-btn">
            <div class="page-index" >
                <span>1</span>
            </div>
            <div class="page-index">
                <span>2</span>
            </div>
            <div class="page-index">
                <span>3</span>
            </div>
            <div class="page-index">
                <span>4</span>
            </div>
            <div class="page-index">
                <span>5</span>
            </div>
            <img src="../../assets/icon/btn-next-page.svg" alt="next-page-btn" class="first-page-btn">
            <img src="../../assets/icon/btn-lastpage.svg" alt="last-page-btn" class="first-page-btn">

        </div>
    </div>
</template>

<style scoped>
.footer{
    position: absolute;
    bottom:0;
    height: 60px;
    left: 24px;
    right: 24px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    border-top: 4px solid #727475;
      background-color: rgb(255, 251, 251);
}

.footer p{
    font-size: 1rem;
  
}

.switch-page {
    position: absolute;
    display: flex;
    right: 20px;
}

.switch-page img{
    cursor: pointer;
}

.page-index {
    display: flex;
    width: 25px;
    height:25px;
    border-radius: 10%;
    border: 1px solid #ccc;
    margin-left: 3px;
    margin-right: 3px;
    cursor: pointer;
}

.page-index:hover {
    background-color: #dedede;
}

.page-index span {
    margin: auto;
    font-size: 1.3rem;
}
#select-paging-number{
    position: absolute;
    font-size: 15px;
    color: #000;
    height: 40px;
    border-radius: 4px;
    /* width: 100px; */
    padding-left: 12px;
    padding-right: 36px;
    border: 1px solid #bbb;
    margin-right: 16px;
    outline: none;
    right: 290px;
}

</style>