// --- 1. LOGIC CHO SIDEBAR ---
function initSidebar() {
    const allSideMenu = document.querySelectorAll('#sidebar .side-menu li a');
    const sidebar = document.getElementById('sidebar');

    if (!sidebar) return; // Kiểm tra an toàn

    allSideMenu.forEach(item => {
        const li = item.parentElement;
        item.addEventListener('click', function () {
            allSideMenu.forEach(i => i.parentElement.classList.remove('active'));
            li.classList.add('active');
        });
    });

    // Tự động ẩn sidebar nếu màn hình nhỏ (Tablet/Phone)
    if (window.innerWidth < 768) {
        sidebar.classList.add('hide');
    }
}

// --- 2. LOGIC CHO NAVBAR & TÌM KIẾM ---
function initNavbar() {
    const menuBar = document.querySelector('#content nav .bx.bx-menu');
    const sidebar = document.getElementById('sidebar');
    const overlay = document.querySelector('.sidebar-overlay');
    const searchButton = document.querySelector('#content nav form .form-input button');
    const searchButtonIcon = document.querySelector('#content nav form .form-input button .bx');
    const searchForm = document.querySelector('#content nav form');
    const closeBtn = document.querySelector('.mobile-close-sidebar');

    function toggleSidebar() {
        if (!sidebar) return;
        const isHidden = sidebar.classList.toggle('hide');
        
        // Xử lý overlay trên mobile
        if (window.innerWidth < 768) {
            if (isHidden) {
                if (overlay) overlay.classList.remove('show');
                document.body.style.overflow = 'auto';
            } else {
                if (overlay) overlay.classList.add('show');
                document.body.style.overflow = 'hidden';
            }
        }
    }

    // Logic Đóng/Mở Sidebar
    if (menuBar) {
        menuBar.addEventListener('click', toggleSidebar);
    }

    // Nút đóng sidebar trên mobile
    if (closeBtn) {
        closeBtn.addEventListener('click', toggleSidebar);
    }

    // Click vào overlay để đóng sidebar
    if (overlay) {
        overlay.addEventListener('click', toggleSidebar);
    }

    // Logic nút tìm kiếm trên màn hình nhỏ
    if (searchButton && searchForm) {
        searchButton.addEventListener('click', function (e) {
            if (window.innerWidth < 576) {
                e.preventDefault();
                searchForm.classList.toggle('show');
                if (searchForm.classList.contains('show')) {
                    if (searchButtonIcon) searchButtonIcon.classList.replace('bx-search', 'bx-x');
                } else {
                    if (searchButtonIcon) searchButtonIcon.classList.replace('bx-x', 'bx-search');
                }
            }
        });
    }

    // Xử lý khi resize màn hình
    window.addEventListener('resize', function () {
        if (this.innerWidth > 576) {
            if (searchButtonIcon) searchButtonIcon.classList.replace('bx-x', 'bx-search');
            if (searchForm) searchForm.classList.remove('show');
        }
        
        // Nếu resize lên desktop, xóa overlay và scroll
        if (this.innerWidth >= 768) {
            if (overlay) overlay.classList.remove('show');
            document.body.style.overflow = 'auto';
        }
    });
}

// --- 3. LOGIC CHO FILTER SLIDE-DOWN ---
function initFilter() {
    const filterToggles = document.querySelectorAll('.filter-toggle');
    
    filterToggles.forEach(toggle => {
        toggle.addEventListener('click', function() {
            const targetId = this.getAttribute('data-target');
            const target = document.getElementById(targetId);
            
            if (target) {
                const isShowing = target.classList.toggle('show');
                
                // Đổi icon khi mở/đóng
                // Nếu bản thân toggle là icon (có class bx)
                if (this.classList.contains('bx')) {
                    if (isShowing) {
                        this.classList.replace('bx-filter', 'bx-x');
                    } else {
                        this.classList.replace('bx-x', 'bx-filter');
                    }
                } else {
                    // Nếu icon nằm bên trong toggle
                    const icon = this.querySelector('.bx');
                    if (icon) {
                        if (isShowing) {
                            icon.classList.replace('bx-filter', 'bx-x');
                        } else {
                            icon.classList.replace('bx-x', 'bx-filter');
                        }
                    }
                }
            }
        });
    });
}