function Footer(){
    return (
        <footer id="footer"  className="footer">
			<div className="container">
				<div className="hm-footer-copyright text-center">
					<div className="footer-social">
						<a href="https://www.facebook.com/"><i className="fa fa-facebook"></i></a>	
						<a href="https://www.instagram.com/"><i className="fa fa-instagram"></i></a>
						<a href="https://www.linkedin.com/"><i className="fa fa-linkedin"></i></a>
						<a href="https://www.pinterest.com/"><i className="fa fa-pinterest"></i></a>
						<a href="https://www.behance.net/"><i className="fa fa-behance"></i></a>	
					</div>
					<p>
						&copy;copyright. designed and developed by <a href="https://www.themesine.com/">themesine</a>
					</p>
				</div>
			</div>

			<div id="scroll-Top">
				<div className="return-to-top">
					<i className="fa fa-angle-up " id="scroll-top" data-toggle="tooltip" data-placement="top" title="" data-original-title="Back to Top" aria-hidden="true"></i>
				</div>
				
			</div>
			
		</footer>
    )
}

export default Footer;