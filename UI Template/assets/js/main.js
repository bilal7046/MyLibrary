
document.addEventListener('DOMContentLoaded', function(){
  const btn = document.getElementById('sidebarToggle');
  const sidebar = document.getElementById('sidebar');
  const overlay = document.getElementById('overlay');
  if(btn){
    btn.addEventListener('click', ()=>{
      sidebar.classList.toggle('show');
      overlay.classList.toggle('show');
    });
    overlay.addEventListener('click', ()=>{
      sidebar.classList.remove('show');
      overlay.classList.remove('show');
    });
  }
  // demo delete confirmation
  document.querySelectorAll('.btn-delete').forEach(b=> b.addEventListener('click', (e)=>{
    e.preventDefault();
    if(confirm('Are you sure you want to delete this record?')){
      showToast('Record deleted successfully','Success','success');
    }
  }));
});

function showToast(message, title='Notice', type='info'){
  const colors = {info:'primary', success:'success', danger:'danger', warning:'warning'};
  const toastWrap = document.getElementById('toastWrap');
  const id = 't'+Date.now();
  const color = colors[type] || 'primary';
  const el = document.createElement('div');
  el.className = 'toast align-items-center text-bg-'+color+' border-0';
  el.role = 'alert';
  el.ariaLive = 'assertive';
  el.ariaAtomic = 'true';
  el.id = id;
  el.style.minWidth = '220px';
  el.innerHTML = `<div class="d-flex"><div class="toast-body"><strong>${title}</strong><div>${message}</div></div><button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button></div>`;
  toastWrap.appendChild(el);
  const t = new bootstrap.Toast(el, { delay: 3500 });
  t.show();
  el.addEventListener('hidden.bs.toast', ()=> el.remove());
}
